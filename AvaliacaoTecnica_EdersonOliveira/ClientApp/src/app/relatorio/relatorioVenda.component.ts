import { Component } from '@angular/core';
import { RelatorioDeVendaDto } from '../models/relatorioDeVenda';
import { RelatorioService } from '../services/relatorio.service';
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
    selector: 'app-relatoriodevenda',
    templateUrl: './relatorioVenda.component.html',
})
export class RelatorioDeVendasComponent {

    dataMinima: string;
    dataMaxima: string;
    relatorioDeVendas: RelatorioDeVendaDto[] = [];

    constructor(private relatorioService: RelatorioService) {
    }

    gerar() {
        if (!!this.dataMinima && !!this.dataMaxima) {
            this.relatorioService.ObterVendas(this.dataMinima, this.dataMaxima).then(result => {
                this.relatorioDeVendas = result;
                console.log(result);
            });
        }
    }

    imprimir() {
        const data = document.getElementById('tabelaImprimir');
        html2canvas(data).then(canvas => {
            const imgWidth = 208;
            const pageHeight = 295;
            const imgHeight = canvas.height * imgWidth / canvas.width;
            const heightLeft = imgHeight;
            const contentDataURL = canvas.toDataURL('image/png');
            const pdf = new jspdf('p', 'mm', 'a4');
            const position = 0;
            pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)
            pdf.save('relatorio.pdf');
        });
    }
}
