import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RelatorioDeVendaDto } from '../models/relatorioDeVenda';


@Injectable()
export class RelatorioService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ObterVendas(dataMinima: string, dataMaxima: string) {
        return this.http.get<RelatorioDeVendaDto[]>(this.baseUrl + 'api/relatorio/venda',
            { params: { dataMinima: dataMinima, dataMaxima: dataMaxima } }).toPromise();
    }
}
