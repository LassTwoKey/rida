import type { Metadata } from "next";
import Footer from "@/widgets/footer/footer";
import "../index.css";

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
      <div className='bg-[#DBD3D3] h-screen w-full'>
              { children }
      </div>
      <Footer/>
      </body>
    </html>
  );
}
