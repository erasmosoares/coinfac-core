import { AccountComponentService } from "./pages/account/account.component.service";
import { OrderModule } from "ngx-order-pipe";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";

import { HttpModule } from "@angular/http";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { MainComponent } from "./pages/main/main.component";
import { NgxChartsModule } from "@swimlane/ngx-charts";
import { NavbarComponent } from "./components/navbar/navbar.component";
import { NotFoundComponent } from "./pages/not-found/not-found.component";
import { AccountComponent } from "./pages/account/account.component";
import { IncomeComponent } from "./pages/income/income.component";
import { ExpenseComponent } from "./pages/expense/expense.component";
import { ForeignCurrencyComponent } from "./pages/foreign-currency/foreign-currency.component";
import { PredictionComponent } from "./pages/prediction/prediction.component";
import { BlockchainComponent } from "./pages/blockchain/blockchain.component";
import { RouterModule } from "@angular/router";
import { JumbotronComponent } from "./components/jumbotron/jumbotron.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatTabsModule } from "@angular/material/tabs";
import { NgxSmartModalModule, NgxSmartModalService } from "ngx-smart-modal";
import { AccountModalComponent } from "./pages/account-modal/account-modal.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { TitleCasePipe } from "./pipes/titlecase.pipe";
import { AuthGuard } from "./components/auth.guard";
import { ProfileComponent } from "./components/profile/profile.component";
import { ToastrModule } from "ngx-toastr";
import { DatePipe } from "@angular/common";
import { AccountModalService } from "./pages/account-modal/account.modal.service";

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    NavbarComponent,
    NotFoundComponent,
    AccountComponent,
    IncomeComponent,
    ExpenseComponent,
    ForeignCurrencyComponent,
    PredictionComponent,
    BlockchainComponent,
    JumbotronComponent,
    AccountModalComponent,
    ProfileComponent,
    TitleCasePipe,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxChartsModule,
    HttpModule,
    HttpClientModule,
    FontAwesomeModule,
    OrderModule,
    MatToolbarModule,
    MatTabsModule,
    ToastrModule.forRoot(),
    NgxSmartModalModule.forChild(),
    NgxSmartModalModule.forRoot(),
    RouterModule.forRoot([
      { path: "home", component: MainComponent },
      {
        path: "accounts",
        component: AccountComponent,
        canActivate: [AuthGuard],
      },
      { path: "income", component: IncomeComponent, canActivate: [AuthGuard] },
      {
        path: "expense",
        component: ExpenseComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "foreigncurrency",
        component: ForeignCurrencyComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "prediction",
        component: PredictionComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "blockchain",
        component: BlockchainComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "profile",
        component: ProfileComponent,
        canActivate: [AuthGuard],
      },
      { path: "**", component: MainComponent },
    ]),
  ],
  providers: [
    NgxSmartModalService,
    AccountComponentService,
    AccountModalService,
  ],
  exports: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
