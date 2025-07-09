"use client";

import Advantages from "@/features/advantages/advantages";
import Banner from "@/features/banner/banner";
import FaqQuestion from "@/features/faq-question/faq-question";
import DeliveryPartners from "@/features/partners/delivery-partners";
import PartnersList from "@/features/partners/partnerts-list";

const MainPage = () => {
    return (
        <div className="flex flex-col gap-5">
            <Banner />
            <PartnersList />
            <Advantages />
            <FaqQuestion />
            <DeliveryPartners />
        </div>
    );
};

export default MainPage;
