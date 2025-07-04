import Footer  from "@/widgets/footer/footer";
import Container  from "@/shared/components/container/container";
import Card from "@/features/card/card";
import { Button } from "@/shared/ui/button";
import { Input } from "@/shared/ui/input";
import Header from "@/widgets/header/header";
import Banner from "@/features/banner/banner";
import PartnertsList from "@/features/partners/partnerts-list";
import Advantages from "@/features/advantages/advantages";
import DeliveryPartners from "@/features/partners/delivery-partners";


const TestPage = () => {
    return (
        <Container>
             <DeliveryPartners/>
        </Container>
    )
}

export default  TestPage