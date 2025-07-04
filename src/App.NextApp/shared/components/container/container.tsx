"use client";

const Container = ({ children }: { children: React.ReactNode }) => {
    return <div className="max-w-[1440px] m-auto py-10">{children}</div>;
};

export default Container;
