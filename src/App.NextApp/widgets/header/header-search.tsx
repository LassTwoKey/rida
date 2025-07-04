import { Input } from "@/shared/ui/input";
import { Search } from "lucide-react";

const HeaderSearch = () => {
    return (
        <div className="flex relative pt-4">
            <Input placeholder="Search..." className="relative pl-3 pr-9" />
            <Search size={18} color="#222222" className="absolute top-8 right-4" />
        </div>
    );
};

export default HeaderSearch;
