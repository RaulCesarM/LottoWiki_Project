import { OcurrencesService } from 'src/app/services/ocurrences.service';
import { Chart, ChartTypeRegistry, LegendItem } from 'chart.js/auto';
import { OverdueService } from 'src/app/services/overdue.service';
import { RankingService } from 'src/app/services/ranking.service';
import { DoOverService } from 'src/app/services/doover.service';
import { LotoFacilSmall } from 'src/app/models/lotoFacilSmall';
import { MathService } from 'src/app/services/math.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-charts-rankings',
  templateUrl: './charts-rankings.component.html',
  styleUrls: ['./charts-rankings.component.css'],
})
export class ChartsRankingsComponent implements OnInit {
  typeChart: string = 'bar';
  title = 'ng-chart';
  chartRanking: any = [];
  isSorted: boolean = false;
  isAvaregeShow: boolean = false;
  isExponentialTrendLineShow: boolean = false;
  isArithmeticTrendLineShow: boolean = false;
  isLogarithmLineDataTrendLineShow: boolean = false;
  isFormulaShow: boolean = false
  isOcurrenceActive: boolean = false;
  isOverdueActive: boolean = false;
  isDoOverActive: boolean = false;
  isOutliersShow: boolean = true;
  originalData: any[] | undefined;
  originalLabels: string[] = [];
  originalDataSource: number[] = [];
  concurso: number = 0;

  constructor(
    private mathService: MathService,
    private rankingService: RankingService,
    private overdueService: OverdueService,
    private dooverService: DoOverService,
    private ocurrencesService: OcurrencesService
  ) {}

  async ngOnInit(): Promise<void> {
    this.isOcurrenceActive = true
    const smallModel: LotoFacilSmall = await this.ocurrencesService.getData();
    this.originalDataSource = [...smallModel.values]
    this.originalLabels = Array.from({ length: 25 }, (_, i) => (i + 1).toString());
    this.showChart();
    this.initChart();
  }


  private showChart(type?: string): void {
    this.chartRanking = new Chart('canvas', {
      type: (type as keyof ChartTypeRegistry) || 'bar',
      data: {
        labels: [...this.rankingService.labelsDataSource],
        datasets: this.rankingService.getDataSets().map((dataset, index) => ({
          ...dataset,
          hidden: index !== 0
        }))
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          x: {
            ticks: {
              font: { size: 8 },
              maxRotation: 0,
              minRotation: 0,
              autoSkip: true,
              autoSkipPadding: 0,
            }
          },
          y: {
            ticks: {
              font: { size: 7 },
              maxRotation: 0,
              minRotation: 0,
              autoSkip: true,
              autoSkipPadding: 0
            },
            beginAtZero: true,
            offset: true,
            grid: { display: true },
          },
        },
        plugins: {
          title: { display: true },
          legend: {
            display: true,
            labels: {
              font: { size: 14 },
              boxWidth: 20,
              padding: 10,
              generateLabels: (chart): LegendItem[] => {
                return chart.data.datasets.map((dataset, index) => ({
                  datasetIndex: index,
                  text: '',
                  fillStyle: dataset.backgroundColor as string,
                  strokeStyle: dataset.borderColor as string,
                  lineWidth: 2,
                  hidden: dataset.hidden,
                  pointStyle: 'rect'
                }));
              }
            }
          }
        }
      }
    });

    this.originalData = JSON.parse(JSON.stringify(this.chartRanking.data.datasets[0].data));
    this.originalLabels = JSON.parse(JSON.stringify([...this.chartRanking.data.labels]));
  }

  private setFlagsFalse(): void {
    this.isOcurrenceActive = false;
    this.isOverdueActive = false;
    this.isDoOverActive = false;
  }

  protected async updateDataSourceBasedOnEvent(event: string): Promise<void> {
    if (event === 'ocurrences' && !this.isOcurrenceActive) {
      this.setFlagsFalse();
      this.isOcurrenceActive = true;
      let smallModel = await this.ocurrencesService.getData();
      this.chartRanking.data.datasets[0].data = [...smallModel.values];
      this.concurso = smallModel.concurso
      this.checkSorted();
      this.updateChartAndTrendLines();
      this.chartRanking.update();
    }
    if (event === 'overdue' && !this.isOverdueActive) {
      this.setFlagsFalse();
      this.isOverdueActive = true;
      let smallModel = await this.overdueService.getData();
      this.chartRanking.data.datasets[0].data = [...smallModel.values];
      this.concurso = smallModel.concurso
      this.checkSorted();
      this.updateChartAndTrendLines();
      this.chartRanking.update();
    }
    if (event === 'doover' && !this.isDoOverActive) {
      this.setFlagsFalse();
      this.isDoOverActive = true;
      let smallModel = await this.dooverService.getData();
      this.chartRanking.data.datasets[0].data = [...smallModel.values];
      this.concurso = smallModel.concurso
      this.checkSorted();
      this.updateChartAndTrendLines();
      this.chartRanking.update();
    }
  }

  initChart(): void {
    this.chartRanking.data.datasets[0].data = [... this.originalDataSource];
    this.checkSorted();
    this.updateChartAndTrendLines();
    this.chartRanking.update();
  }

  private updateChartAndTrendLines(): void {
    this.addExponentialArithmeticTrendLine();
    this.addArithmeticTrendLine();
    this.addAvarege();
  }

  protected toggleSorted(): void {
    this.isSorted = !this.isSorted;
    this.checkSorted();
    this.updateChartAndTrendLines();
  }

  private checkSorted(): void {
    if (this.isSorted) {
      this.sort();
    } else {
      this.unsort();
    }
  }

  private sort(): void {
    let data: number[] = this.chartRanking.data.datasets[0].data;
    const labels: string[] = this.chartRanking.data.labels;
    this.mathService.sort(data, labels);
    this.chartRanking.update();
  }

  private unsort(): void {
    let data: number[] = this.chartRanking.data.datasets[0].data;
    const labels: string[] = this.chartRanking.data.labels;
    this.mathService.unSort(data, labels);
    this.chartRanking.update();
  }


  private async addArithmeticTrendLine(): Promise<void> {
    const data: number[] = this.chartRanking.data.datasets[0].data;
    this.isArithmeticTrendLineShow = true;
    const trendLineData: number[] = await this.mathService.calculateArithmeticTrendLine(data);
    this.chartRanking.data.datasets[3].data = trendLineData;
    this.chartRanking.update();
  }

  private async addExponentialArithmeticTrendLine(): Promise<void> {
    const data: number[] = this.chartRanking.data.datasets[0].data;
    this.isExponentialTrendLineShow = true;
    const trendExponetialLineData: number[] = await this.mathService.calculateExponentialTrendLine(data);
    this.chartRanking.data.datasets[2].data = trendExponetialLineData;
    this.chartRanking.update();
  }

  private async addAvarege(): Promise<void> {
    const data: number[] = this.chartRanking.data.datasets[0].data;
    const media: number = await this.mathService.calculateAverage(data);
    this.chartRanking.data.datasets[1].data = Array(data.length).fill(media);
    this.chartRanking.update();
  }

}
