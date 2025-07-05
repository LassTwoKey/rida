import getConfig from "next/config";
import axios from "axios";

const CoreAbortController = new AbortController();

const baseURL = process.env.NEXT_PUBLIC_APP_URL;

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
