import { Bell } from "lucide-react";

const HeaderLogo = () => {
    return (
        <div className="flex justify-between items-center">
            <h2 className="font-semibold text-2xl">RIDA</h2>
            <Bell size={20} />
        </div>
    );
};

export default HeaderLogo;
