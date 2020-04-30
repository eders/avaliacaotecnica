import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AnuncioDto } from '../models/anuncio';

@Injectable()
export class AnuncioService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    listarAnuncios() {
        return this.http.get<AnuncioDto[]>(this.baseUrl + 'api/anuncio').toPromise();
    }

    obterAnuncio(id: number) {
        return this.http.get<AnuncioDto>(this.baseUrl + 'api/anuncio/' + id).toPromise();
    }

    adicionarAnuncio(anuncio: AnuncioDto) {
        return this.http.post(this.baseUrl + 'api/anuncio/', anuncio).toPromise();
    }

    alterarAnuncio(anuncio: AnuncioDto) {
        return this.http.put(this.baseUrl + 'api/anuncio/' + anuncio.id, anuncio).toPromise();
    }

    deletarAnuncio(id: number) {
        return this.http.delete(this.baseUrl + 'api/anuncio/' + id).toPromise();
    }
}
