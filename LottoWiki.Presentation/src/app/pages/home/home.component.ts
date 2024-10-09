import { Component, OnInit } from '@angular/core';
import { CorrelationsService } from 'src/app/services/correlations.service';
import { OcurrencesService } from 'src/app/services/ocurrences.service';
import { OverdueService } from 'src/app/services/overdue.service';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(
    private overdueService: OverdueService,
    private ocurrencesService: OcurrencesService,
    private correlationsService: CorrelationsService,
     private statusService: StatusService
  ) {}

 async ngOnInit(): Promise<void >{
    
   await this.overdueService.preloadData();
   await this.ocurrencesService.preloadData();
   await  this.correlationsService.preloadData();
   await this.statusService.preloadData();
  };
}