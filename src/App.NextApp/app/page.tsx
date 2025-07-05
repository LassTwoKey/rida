"use client";

import { useEffect } from "react";
import { getAllProducts } from "@/api/controllers/products";

export default function Page() {
    useEffect(() => {
        getAllProducts((data) => {
            console.log(data);
        });
    }, []);
    return <div className=""></div>;
}
