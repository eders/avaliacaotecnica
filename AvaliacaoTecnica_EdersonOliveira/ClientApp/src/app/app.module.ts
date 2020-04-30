import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { MarcaService } from './services/marca.service';
import { MarcaComponent } from './marca/marca.component';
import { AdicionarMarcaComponent } from './marca/adicionarMarca.component';
import { AlterarMarcaComponent } from './marca/alterarMarca.component';
import { ModeloComponent } from './modelo/modelo.component';
import { AdicionarModeloComponent } from './modelo/adicionarModelo.component';
import { AlterarModeloComponent } from './modelo/alterarModelo.component';
import { ModeloService } from './services/modelo.service';
import { AnuncioComponent } from './anuncio/anuncio.component';
import { AnuncioService } from './services/anuncio.service';
import { AdicionarAnuncioComponent } from './anuncio/adicionarAnuncio.component';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { AlterarAnuncioComponent } from './anuncio/alterarAnuncio.component';
import { RelatorioService } from './services/relatorio.service';
import { RelatorioDeVendasComponent } from './relatorio/relatorioVenda.component';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MarcaComponent,
    AdicionarMarcaComponent,
    AlterarMarcaComponent,
    ModeloComponent,
    AdicionarModeloComponent,
    AlterarModeloComponent,
    AnuncioComponent,
    AdicionarAnuncioComponent,
    AlterarAnuncioComponent,
    RelatorioDeVendasComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'marcas', component: MarcaComponent },
      { path: 'marcas/adicionar', component: AdicionarMarcaComponent },
      { path: 'marcas/alterar/:id', component: AlterarMarcaComponent },
      { path: 'modelos', component: ModeloComponent },
      { path: 'modelos/adicionar', component: AdicionarModeloComponent },
      { path: 'modelos/alterar/:id', component: AlterarModeloComponent },
      { path: 'anuncios', component: AnuncioComponent },
      { path: 'anuncios/adicionar', component: AdicionarAnuncioComponent },
      { path: 'anuncios/alterar/:id', component: AlterarAnuncioComponent },
      { path: 'relatorios', component: RelatorioDeVendasComponent },
    ])
  ],
  providers: [MarcaService, ModeloService, AnuncioService,
    RelatorioService, 
    { provide: LOCALE_ID, useValue: 'pt-BR' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
