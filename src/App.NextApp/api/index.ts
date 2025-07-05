import getConfig from "next/config";
import axios from "axios";

const CoreAbortController = new AbortController();

const baseURL = process.env.NODE_ENV === "production" ? window.location.host : "147.78.66.97";

const CoreHttp = axios.create({
    withCredentials: true,
    baseURL: `//${baseURL}/api`,
    signal: CoreAbortController.signal
});

CoreHttp.interceptors.response.use(
    (response) => {
        return response;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export { CoreHttp, CoreAbortController };
