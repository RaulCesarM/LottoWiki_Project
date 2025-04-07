import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CorrelationsComponent } from './charts-module/correlations/correlations.component';
import { ChartsRankingsComponent } from './charts-module/charts-rankings/charts-rankings.component';
import { ChartsOnionComponent } from './charts-module/charts-onion/charts-onion.component';
import { HomeComponent } from './pages/home/home.component';
import { StatusComponent } from './charts-module/status/status.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'onion', component: ChartsOnionComponent},
  { path: 'home', component: HomeComponent },
  { path: 'ranking', component: ChartsRankingsComponent},
   { path: 'correl', component: CorrelationsComponent}, 
   { path: 'status', component: StatusComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
