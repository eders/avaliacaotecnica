import { Component } from '@angular/core';
import { MarcaService } from '../services/marca.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { LocationStrategy } from '@angular/common';
import { MarcaDto } from '../models/marca';
import { ModeloService } from '../services/modelo.service';
import { ModeloDto } from '../models/modelo';
import { AnuncioDto, ECor, ETipoDeCombustivel } from '../models/anuncio';
import { AnuncioService } from '../services/anuncio.service';

@Component({
    selector: 'app-adicionar-anuncio',
    templateUrl: './adicionaranuncio.component.html',
    styleUrls: ['./adicionaranuncio.component.css']
})

export class AdicionarAnuncioComponent {

    checkoutForm: FormGroup;
    marcas: MarcaDto[];
    modelos: ModeloDto[];
    eCor = ECor;
    cores: any;
    eTipoDeCombustivel = ETipoDeCombustivel;
    combustiveis: any;

    constructor(private anuncioService: AnuncioService,
        private modeloService: ModeloService,
        private marcaService: MarcaService,
        private formBuilder: FormBuilder,
        private locationStrategy: LocationStrategy) {

        this.listarMarcas();

        this.cores = Object.keys(this.eCor).filter(x => !isNaN(Number(x)));
        this.combustiveis = Object.keys(this.eTipoDeCombustivel).filter(x => !isNaN(Number(x)));

        this.criarFormulario();
    }

    listarMarcas() {
        this.marcaService
            .listarMarcas().then(result => this.marcas = result);
    }

    listarModelos(marcaId: number) {
        this.modeloService.obterModeloPorMarca( Number(marcaId)).then(result => this.modelos = result);
    }

    criarFormulario() {
        this.checkoutForm = this.formBuilder.group({
            id: '',
            valorDeCompra: ['', Validators.required],
            valorDeVenda: ['', Validators.required],
            cor: ['', Validators.required],
            tipoDeCombustivel: ['', Validators.required],
            dataDeVenda: ['', Validators.required],
            modeloId: ['', Validators.required],
            marcaId: ['', Validators.required]
        });
    }

    onSubmit(customerData: AnuncioDto) {
        if (this.checkoutForm.valid) {
            customerData.id =  Number(customerData.id);
            customerData.modeloId = Number(customerData.modeloId);
            customerData.marcaId = Number(customerData.marcaId);
            customerData.cor =  Number(customerData.cor);
            customerData.tipoDeCombustivel =  Number(customerData.tipoDeCombustivel);
            this.anuncioService.adicionarAnuncio(customerData).then(() => {
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

