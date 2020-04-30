import { Component } from '@angular/core';
import { MarcaService } from '../services/marca.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { LocationStrategy } from '@angular/common';
import { MarcaDto } from '../models/marca';

@Component({
    selector: 'app-adicionar-marca',
    templateUrl: './adicionarMarca.component.html',
    styleUrls: ['./adicionarMarca.component.css']
})

export class AdicionarMarcaComponent {

    checkoutForm: FormGroup;

    constructor(private marcaService: MarcaService,
        private formBuilder: FormBuilder,
        private locationStrategy: LocationStrategy) {

        this.criarFormulario();
    }

    criarFormulario() {
        this.checkoutForm = this.formBuilder.group({
            nome: ['', Validators.required]
        });
    }

    onSubmit(customerData: MarcaDto) {
        if (this.checkoutForm.valid) {
            this.marcaService.adicionarMarca(customerData).then(() => {
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

