import { CoreHttp } from "@/api";

type Product = any; // Замените на конкретный тип ваших продуктов
type ErrorType = unknown;

type SendResultCallback<T = Product[]> = (data: T) => void;
type ErrorCallback = (error: ErrorType) => void;

const getAllProducts = async (sendResult?: SendResultCallback, onError?: ErrorCallback) => {
    try {
        const response = await CoreHttp.get("/products");
        if (typeof sendResult === "function") {
            sendResult(response.data);
        }
    } catch (err) {
        if (typeof onError === "function") {
            onError(err);
        }
    }
};

export { getAllProducts };
