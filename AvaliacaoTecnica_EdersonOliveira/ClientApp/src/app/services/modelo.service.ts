import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MarcaDto } from '../models/marca';
import { ModeloDto } from '../models/modelo';


@Injectable()
export class ModeloService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    listarModelos() {
        return this.http.get<ModeloDto[]>(this.baseUrl + 'api/modelo').toPromise();
    }

    obterModelo(id: number) {
        return this.http.get<ModeloDto>(this.baseUrl + 'api/modelo/' + id).toPromise();
    }

    obterModeloPorMarca(marcaId: number) {
        return this.http.get<ModeloDto[]>(this.baseUrl + 'api/modelo/marca/' + marcaId).toPromise();
    }

    adicionarModelo(marca: ModeloDto) {
        return this.http.post(this.baseUrl + 'api/modelo/', marca).toPromise();
    }

    alterarModelo(marca: ModeloDto) {
        return this.http.put(this.baseUrl + 'api/modelo/' + marca.id, marca).toPromise();
    }

    deletarModelo(id: number) {
        return this.http.delete(this.baseUrl + 'api/modelo/' + id).toPromise();
    }
}
