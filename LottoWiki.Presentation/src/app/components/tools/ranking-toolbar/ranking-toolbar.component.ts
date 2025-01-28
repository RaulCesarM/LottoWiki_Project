import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-ranking-toolbar',
  templateUrl: './ranking-toolbar.component.html',
  styleUrls: ['./ranking-toolbar.component.css']
})
export class RankingToolbarComponent {
  @Input() isSorted: boolean = false;
  @Input() isOcurrenceActive: boolean = false;
  @Input() isOverdueActive: boolean = false;
  @Input() isDoOverActive: boolean = false;
  @Input() isAvaregeShow: boolean = false;
  @Input() isExponentialTrendLineShow: boolean = false;
  @Input() isArithmeticTrendLineShow: boolean = false;
  @Input() isLogarithmLineDataTrendLineShow: boolean = false;
  @Input() isFormulaShow: boolean = false;

  @Output() toggleSorted = new EventEmitter<void>();
  @Output() toggleAvarege = new EventEmitter<void>();
  @Output() toggleExponentialTrendLine = new EventEmitter<void>();
  @Output() toggleArithmeticTrendLine = new EventEmitter<void>();
  @Output() toggleLogarithmTrendLine = new EventEmitter<void>();
  @Output() toggleShowFormula = new EventEmitter<void>();
  @Output() updateDataSourceBasedOnEvent = new EventEmitter<string>();

  emitUpdate(eventType: string): void {
    this.updateDataSourceBasedOnEvent.emit(eventType);
  }

}
