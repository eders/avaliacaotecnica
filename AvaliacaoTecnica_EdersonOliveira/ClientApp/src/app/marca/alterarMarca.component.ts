import { Component } from '@angular/core';
import { MarcaService } from '../services/marca.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { LocationStrategy } from '@angular/common';
import { MarcaDto } from '../models/marca';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-alterar-marca',
    templateUrl: './alterarMarca.component.html',
    styleUrls: ['./alterarMarca.component.css']
})

export class AlterarMarcaComponent {

    checkoutForm: FormGroup;
    marca: MarcaDto;
    id: number;

    constructor(private marcaService: MarcaService,
        private route: ActivatedRoute,
        private formBuilder: FormBuilder,
        private locationStrategy: LocationStrategy) {

        this.route.params.subscribe(params => {
            this.id = params['id'];
        });

        this.criarFormulario();

        this.atualizarMarca();
    }

    private atualizarMarca() {
        this.marcaService.obterMarca(this.id).then(result => {
            this.marca = result;
            this.atualizarFormulario();
        });
    }

    criarFormulario() {
        this.checkoutForm = this.formBuilder.group({
            id: '',
            nome: ['', Validators.required]
        });
    }

    atualizarFormulario() {
        this.checkoutForm.setValue({
            id: this.marca.id || '',
            nome: this.marca.nome || ''
        });
    }

    onSubmit(customerData: MarcaDto) {
        if (this.checkoutForm.valid) {
            customerData.id = Number(customerData.id);
            this.marcaService.alterarMarca(customerData).then(result => {
                this.atualizarMarca();
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

