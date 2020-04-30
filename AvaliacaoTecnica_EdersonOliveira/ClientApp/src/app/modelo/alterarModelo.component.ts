import { Component } from '@angular/core';

import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { LocationStrategy } from '@angular/common';

import { ActivatedRoute } from '@angular/router';
import { ModeloDto } from '../models/modelo';
import { ModeloService } from '../services/modelo.service';
import { MarcaService } from '../services/marca.service';
import { MarcaDto } from '../models/marca';

@Component({
    selector: 'app-alterar-modelo',
    templateUrl: './alterarModelo.component.html',
    styleUrls: ['./alterarModelo.component.css']
})

export class AlterarModeloComponent {

    checkoutForm: FormGroup;
    marcas: MarcaDto[];
    modelo: ModeloDto;
    id: number;

    constructor(private modeloService: ModeloService,
        private marcaService: MarcaService,
        private route: ActivatedRoute,
        private formBuilder: FormBuilder,
        private locationStrategy: LocationStrategy) {

        this.route.params.subscribe(params => {
            this.id = params['id'];
        });

        this.listarMarcas();

        this.criarFormulario();

        this.atualizarModelo();
    }

    listarMarcas() {
        this.marcaService
            .listarMarcas().then(result => this.marcas = result);
    }

    private atualizarModelo() {
        this.modeloService.obterModelo(this.id).then(result => {
            this.modelo = result;
            this.atualizarFormulario();
        });
    }

    criarFormulario() {
        this.checkoutForm = this.formBuilder.group({
            id: '',
            nome: ['', Validators.required],
            ano: ['', Validators.required],
            marcaId: ['', Validators.required]
        });
    }

    atualizarFormulario() {
        this.checkoutForm.setValue({
            id: this.modelo.id || '',
            nome: this.modelo.nome || '',
            ano: this.modelo.ano || '',
            marcaId: this.modelo.marcaId || ''
        });
    }

    onSubmit(customerData: ModeloDto) {
        if (this.checkoutForm.valid) {
            customerData.id = Number(customerData.id);
            customerData.marcaId = Number(customerData.marcaId);
            this.modeloService.alterarModelo(customerData).then(result => {
                this.atualizarModelo();
            });
        } else {
            this.validateAllFormFields(this.checkoutForm);
        }
    }

    validateAllFormFields(formGroup: FormGroup) {
        Object.keys(formGroup.controls).forEach(field => {
            console.log(field);
            const control = formGroup.get(field);
            if (control instanceof FormControl) {
                control.markAsTouched({ onlySelf: true });
            } else if (control instanceof FormGroup) {
                this.validateAllFormFields(control);
            }
        });
    }

    voltar() {
        this.locationStrategy.back();
    }
}

