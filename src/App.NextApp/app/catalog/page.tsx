import Filters from "@/features/filters/filters";
import BrandsPartners from "@/features/partners/brands-partners";

const CatalogPage = () => {
    return (
        <div className="flex flex-col gap-8">
            <BrandsPartners />
            <Filters />
        </div>
    );
};

export default CatalogPage;
