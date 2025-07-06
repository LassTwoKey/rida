"use client";

import Banner from "@/features/banner/banner";
import PartnersList from "@/features/partners/partnerts-list";
import Advantages from "@/features/advantages/advantages";
import DeliveryPartners from "@/features/partners/delivery-partners";
import FaqQuestion from "@/features/faq-question/faq-question";

const MainPage = () => {
   return (
       <div className='flex flex-col gap-5'>
           <Banner/>
           <PartnersList/>
           <Advantages/>
           <FaqQuestion/>
           <DeliveryPartners/>
       </div>
   )
}

export default MainPage;
