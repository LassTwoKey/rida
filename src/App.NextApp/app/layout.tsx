import type { Metadata } from "next";
import Footer from "@/widgets/footer/footer";
import "../index.css";
import Header from "@/widgets/header/header";

export const metadata: Metadata = {
    title: "Rida shop",
    description: "The best clothes shop in the world"
};

export default function RootLayout({
    children
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html suppressHydrationWarning lang="en">
            <head />
            <body>
                <div className="bg-gray-100 p-3 min-h-screen w-full">
                    <Header />
                    {children}
                </div>
                <Footer />
            </body>
        </html>
    );
}
