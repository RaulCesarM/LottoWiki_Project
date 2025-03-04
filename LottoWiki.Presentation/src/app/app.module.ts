import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { NavToolbarComponent } from './nav-modules/nav-toolbar/nav-toolbar.component';
import { NavSidenavComponent } from './nav-modules/nav-sidenav/nav-sidenav.component';
import { NavFooterComponent } from './nav-modules/nav-footer/nav-footer.component';
import { ChartsRankingsComponent } from './charts-module/charts-rankings/charts-rankings.component';
import { ChartsMoonsComponent } from './charts-module/charts-moons/charts-moons.component';
import { CorrelationsComponent } from './charts-module/correlations/correlations.component';
import { FormsModule } from '@angular/forms';
import { ChartsOnionComponent } from './charts-module/charts-onion/charts-onion.component';
import { ExplanationCorrelationsComponent } from './components/explanations/explanation-correlations/explanation-correlations.component';
import { ExplanationRankingsComponent } from './components/explanations/explanation-rankings/explanation-rankings.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './pages/home/home.component';
import { NavCorrelationsComponent } from './nav-modules/nav-correlations/nav-correlations.component';
import { StatusComponent } from './charts-module/status/status.component';
import { RankingToolbarComponent } from './components/tools/ranking-toolbar/ranking-toolbar.component';
import { LorenzAttractorComponent } from './components/lorenz-attractor/lorenz-attractor.component';
import { ButtonComponent } from './shared/button/button.component';
import { LegendExplanationComponent } from './components/tools/legend-explanation/legend-explanation.component';


@NgModule({
  declarations: [
    AppComponent,
    NavToolbarComponent,
    NavSidenavComponent,
    NavFooterComponent,
    ChartsRankingsComponent,
    ChartsMoonsComponent,
    CorrelationsComponent,
    ChartsOnionComponent,
    ExplanationCorrelationsComponent,
    ExplanationRankingsComponent,
    HomeComponent,
    NavCorrelationsComponent,
    StatusComponent,
    RankingToolbarComponent,
    LorenzAttractorComponent,
    ButtonComponent,
    LegendExplanationComponent,
   
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    FormsModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatTabsModule,
    MatTooltipModule,
    MatSelectModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
