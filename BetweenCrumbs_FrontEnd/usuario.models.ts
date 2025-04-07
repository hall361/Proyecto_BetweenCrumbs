export interface usuarioRequest{
    strMeal: string;
    strMealThumb: string;
    idMeal: string;
}

export interface usuarioResponse{
    mensaje: string;
    status: boolean;
    data: object;
}