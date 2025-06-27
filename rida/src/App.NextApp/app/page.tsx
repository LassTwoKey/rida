"use client";

import { Button } from "@nextui-org/button";

export default function Page() {

  return (
    <div className={`flex-1 flex flex-col items-center justify-center px-4 py-8 h-full`}>
        <Button
            className="mt-6 rounded-full shadow-lg"
            color="danger"
        >
            Sign Out
        </Button>
    </div>
  );
}
