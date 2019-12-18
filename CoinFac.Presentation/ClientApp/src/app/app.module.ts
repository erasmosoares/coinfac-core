import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { OrderModule } from 'ngx-order-pipe';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AccountComponent } from './pages/account/account.component';
import { AccountModalComponent } from './pages/account-modal/account-modal.component';
import { BlockchainComponent } from './pages/blockchain/blockchain.component';
import { ExpenseComponent } from './pages/expense/expense.component';
import { ForeignCurrencyComponent } from './pages/foreign-currency/foreign-currency.component';
import { IncomeComponent } from './pages/income/income.component';
import { MainComponent } from './pages/main/main.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { PredictionComponent } from './pages/prediction/prediction.component';
import { JumbotronComponent } from './components/jumbotron/jumbotron.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { TitlecasePipe } from './pipes/titlecase.pipe';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from './components/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AccountComponent,
    AccountModalComponent,
    BlockchainComponent,
    ExpenseComponent,
    ForeignCurrencyComponent,
    IncomeComponent,
    MainComponent,
    NotFoundComponent,
    PredictionComponent,
    JumbotronComponent,
    NavbarComponent,
    TitlecasePipe,
    ProfileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    OrderModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent },
      { path: 'home', component: MainComponent },
      { path: 'accounts', component: AccountComponent, canActivate: [AuthGuard] },
      { path: 'income', component: IncomeComponent, canActivate: [AuthGuard] },
      { path: 'expense', component: ExpenseComponent, canActivate: [AuthGuard] },
      { path: 'foreigncurrency', component: ForeignCurrencyComponent, canActivate: [AuthGuard] },
      { path: 'prediction', component: PredictionComponent, canActivate: [AuthGuard] },
      { path: 'blockchain', component: BlockchainComponent, canActivate: [AuthGuard] },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
      { path: '**', component: MainComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
