import { Component } from '@angular/core';
import { MarcaService } from '../services/marca.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { LocationStrategy } from '@angular/common';
import { MarcaDto } from '../models/marca';
import { ModeloService } from '../services/modelo.service';
import { ModeloDto } from '../models/modelo';

@Component({
    selector: 'app-adicionar-modelo',
    templateUrl: './adicionarModelo.component.html',
    styleUrls: ['./adicionarModelo.component.css']
})

export class AdicionarModeloComponent {

    checkoutForm: FormGroup;
    marcas: MarcaDto[];

    constructor(private modeloService: ModeloService,
        private marcaService: MarcaService,
        private formBuilder: FormBuilder,
        private locationStrategy: LocationStrategy) {

        this.listarMarcas();
        this.criarFormulario();
    }

    listarMarcas() {
        this.marcaService
            .listarMarcas().then(result => this.marcas = result);
    }

    criarFormulario() {
        this.checkoutForm = this.formBuilder.group({
            nome: ['', Validators.required],
            ano: ['', Validators.required],
            marcaId: ['', Validators.required],
        });
    }

    onSubmit(customerData: ModeloDto) {
        if (this.checkoutForm.valid) {
            customerData.marcaId = Number(customerData.marcaId);
            this.modeloService.adicionarModelo(customerData).then(() => {
                this.checkoutForm.reset();
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

