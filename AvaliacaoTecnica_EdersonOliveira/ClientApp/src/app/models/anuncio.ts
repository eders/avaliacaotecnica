export class AnuncioDto {
    id: number;
    valorDeCompra: number;
    valorDeVenda: number;
    cor: ECor;
    tipoDeCombustivel: ETipoDeCombustivel;
    dataDeVenda: Date;
    modeloId: number;
    marcaId: number;
    nomeModelo: string;
    nomeMarca: string;
    vendido: boolean;
}

export enum ECor {
    Amarelo = 1,
    Azul = 2,
    Branco = 3,
    Cinza = 4,
    Verde = 5,
    Vermelho = 6,
    Preto = 7
}

export enum ETipoDeCombustivel {
    Diesel = 1,
    Etanol = 2,
    Gasolina = 3,
    GNV = 4
}