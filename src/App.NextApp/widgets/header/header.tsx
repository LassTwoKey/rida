import HeaderLogo from "@/widgets/header/header-logo";
import HeaderSearch from "@/widgets/header/header-search";


const Header = () => {
    return (
        <div className='flex flex-col gap-2 pt-4'>
            <HeaderLogo/>
            <HeaderSearch/>
        </div>
    )
}

export default Header