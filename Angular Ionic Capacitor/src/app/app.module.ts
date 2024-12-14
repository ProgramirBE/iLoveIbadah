import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms'; // Voor formulieren
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent, // Declareer de login- en registercomponenten
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    AppRoutingModule,
    ReactiveFormsModule, // Ondersteuning voor reactieve formulieren
  ],
  providers: [{ provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  schemas: [CUSTOM_ELEMENTS_SCHEMA], // Hiermee worden Ionic-componenten herkend
  bootstrap: [AppComponent],
})
export class AppModule {}
