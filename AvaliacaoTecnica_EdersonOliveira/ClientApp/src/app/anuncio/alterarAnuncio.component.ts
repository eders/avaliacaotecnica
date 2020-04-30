import { Component } from '@angular/core';
import { MarcaService } from '../services/marca.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { LocationStrategy } from '@angular/common';
import { MarcaDto } from '../models/marca';
import { ActivatedRoute } from '@angular/router';
import { ModeloDto } from '../models/modelo';
import { ECor, ETipoDeCombustivel, AnuncioDto } from '../models/anuncio';
import { ModeloService } from '../services/modelo.service';
import { AnuncioService } from '../services/anuncio.service';

@Component({
    selector: 'app-alterar-anuncio',
    templateUrl: './alterarAnuncio.component.html',
    styleUrls: ['./alterarAnuncio.component.css']
})

export class AlterarAnuncioComponent {

    checkoutForm: FormGroup;
    marcas: MarcaDto[];
    modelos: ModeloDto[];
    eCor = ECor;
    cores: any;
    eTipoDeCombustivel = ETipoDeCombustivel;
    combustiveis: any;
    id: number;
    anuncio: AnuncioDto;

    constructor(private anuncioService: AnuncioService,
        private marcaService: MarcaService,
        private modeloService: ModeloService,
        private route: ActivatedRoute,
        private formBuilder: FormBuilder,
        private locationStrategy: LocationStrategy) {

        this.route.params.subscribe(params => {
            this.id = params['id'];
        });

        this.listarMarcas();

        this.cores = Object.keys(this.eCor).filter(x => !isNaN(Number(x)));
        this.combustiveis = Object.keys(this.eTipoDeCombustivel).filter(x => !isNaN(Number(x)));

        this.criarFormulario();

        this.atualizarAnuncio();
    }

    listarMarcas() {
        this.marcaService
            .listarMarcas().then(result => this.marcas = result);
    }

    listarModelos(marcaId: number) {
        this.modeloService.obterModeloPorMarca(Number(marcaId)).then(result => this.modelos = result);
    }

    private atualizarAnuncio() {
        this.anuncioService.obterAnuncio(this.id).then(result => {
            this.anuncio = result;
            this.listarModelos(this.anuncio.marcaId);
            this.atualizarFormulario();
        });
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

    atualizarFormulario() {
        this.checkoutForm.setValue({
            id: this.anuncio.id || '',
            valorDeCompra: this.anuncio.valorDeCompra || '',
            valorDeVenda: this.anuncio.valorDeVenda || '',
            cor: this.anuncio.cor || '',
            tipoDeCombustivel: this.anuncio.tipoDeCombustivel || '',
            dataDeVenda: new Date(this.anuncio.dataDeVenda).toISOString().substr(0, 10) || '',
            modeloId: this.anuncio.modeloId || '',
            marcaId: this.anuncio.marcaId || '',
        });
    }

    onSubmit(customerData: AnuncioDto) {
        if (this.checkoutForm.valid) {
            customerData.id = Number(customerData.id);
            customerData.modeloId = Number(customerData.modeloId);
            customerData.marcaId = Number(customerData.marcaId);
            customerData.cor = Number(customerData.cor);
            customerData.tipoDeCombustivel = Number(customerData.tipoDeCombustivel);
            this.anuncioService.alterarAnuncio(customerData).then(() => {
                this.atualizarAnuncio();
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

