import { Component } from '@angular/core';
import { MarcaDto } from '../models/marca';
import { MarcaService } from '../services/marca.service';

@Component({
    selector: 'app-marca',
    templateUrl: './marca.component.html',
})
export class MarcaComponent {

    marcas: MarcaDto[];

    constructor(private marcaService: MarcaService) {
        this.listar();
    }

    listar() {
        this.marcaService
            .listarMarcas().then(result => this.marcas = result);
    }

    delete(id: number) {
        this.marcaService.deletarMarca(id).then(() => {
            this.listar();
        });
    }
}
