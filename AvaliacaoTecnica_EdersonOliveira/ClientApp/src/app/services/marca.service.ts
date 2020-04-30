import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MarcaDto } from '../models/marca';


@Injectable()
export class MarcaService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    listarMarcas() {
        return this.http.get<MarcaDto[]>(this.baseUrl + 'api/marca').toPromise();
    }

    obterMarca(id: number) {
        return this.http.get<MarcaDto>(this.baseUrl + 'api/marca/' + id).toPromise();
    }

    adicionarMarca(marca: MarcaDto) {
        return this.http.post(this.baseUrl + 'api/marca/', marca).toPromise();
    }

    alterarMarca(marca: MarcaDto) {
        return this.http.put(this.baseUrl + 'api/marca/' + marca.id, marca).toPromise();
    }

    deletarMarca(id: number) {
        return this.http.delete(this.baseUrl + 'api/marca/' + id).toPromise();
    }
}
