import { Component } from '@angular/core';
import { AnuncioDto, ECor, ETipoDeCombustivel } from '../models/anuncio';
import { AnuncioService } from '../services/anuncio.service';

@Component({
    selector: 'app-anuncio',
    templateUrl: './anuncio.component.html',
})
export class AnuncioComponent {

    anuncios: AnuncioDto[];
    eCor = ECor;
    eTipoDeCombustivel = ETipoDeCombustivel;

    constructor(private anuncioService: AnuncioService) {
        this.listar();
    }

    listar() {
        this.anuncioService
            .listarAnuncios().then(result => this.anuncios = result);
    }

    delete(id: number) {
        this.anuncioService.deletarAnuncio(id).then(() => {
            this.listar();
        });
    }
}
