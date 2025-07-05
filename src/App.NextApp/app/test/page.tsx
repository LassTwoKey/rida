import Advantages from "@/features/advantages/advantages";
import Banner from "@/features/banner/banner";
import Card from "@/features/card/card";
import DeliveryPartners from "@/features/partners/delivery-partners";
import PartnertsList from "@/features/partners/partnerts-list";
import Container from "@/shared/components/container/container";
import { Button } from "@/shared/ui/button";
import { Input } from "@/shared/ui/input";
import Footer from "@/widgets/footer/footer";
import Header from "@/widgets/header/header";

const TestPage = () => {
    return (
        <Container>
            <DeliveryPartners />
        </Container>
    );
};

export default TestPage;
