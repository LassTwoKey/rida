"use client";

import { useState } from "react";
import { FAQ_LIST } from "@/shared/constants/faq/faq-list";
import { AnimatePresence, motion } from "framer-motion";
import { Plus, X } from "lucide-react";

const FaqQuestion = () => {
    const [chosenQuestion, setChosenQuestion] = useState<number | null>(null);

    const onHandleChooseQuestion = (id: number) =>
        id === chosenQuestion ? setChosenQuestion(null) : setChosenQuestion(id);

    return (
        <div className="flex flex-col gap-2 my-6">
            <h3 className="text-3xl">FAQ</h3>
            <div className="grid grid-cols-1 gap-5 mt-6">
                {FAQ_LIST.map((item) => (
                    <div
                        key={item.id}
                        onClick={() => onHandleChooseQuestion(item.id)}
                        className="flex cursor-pointer flex-col gap-3 duration-100"
                    >
                        <div className="flex justify-between items-start">
                            <h4 className="text-xl font-semibold uppercase max-w-[298px] lg:max-w-full">
                                {item.title}
                            </h4>
                            {chosenQuestion === item.id ? (
                                <X size={32} fill="#A9A9A9" />
                            ) : (
                                <Plus size={32} fill="#A9A9A9" />
                            )}
                        </div>

                        <AnimatePresence>
                            {chosenQuestion === item.id && (
                                <motion.p
                                    initial={{ opacity: 0, height: 0 }}
                                    animate={{ opacity: 1, height: "auto" }}
                                    exit={{ opacity: 0, height: 0 }}
                                    transition={{ duration: 0.3 }}
                                >
                                    {item.desc}
                                </motion.p>
                            )}
                        </AnimatePresence>

                        <div className="w-full h-[1px] bg-[#0000004D]" />
                    </div>
                ))}
            </div>
        </div>
    );
};

export default FaqQuestion;
