import { Component } from '@angular/core';
import { ModeloDto } from '../models/modelo';
import { ModeloService } from '../services/modelo.service';

@Component({
    selector: 'app-modelo',
    templateUrl: './modelo.component.html',
})
export class ModeloComponent {

    modelos: ModeloDto[];

    constructor(private modeloService: ModeloService) {
        this.listar();
    }

    listar() {
        this.modeloService
            .listarModelos().then(result => this.modelos = result);
    }

    delete(id: number) {
        this.modeloService.deletarModelo(id).then(() => {
            this.listar();
        });
    }
}
