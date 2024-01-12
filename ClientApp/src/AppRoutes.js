import Home from "./components/Pages/Home/Home";
import Company from "./components/Pages/Company/Company";
import Product from "./components/Pages/Product/Product";
import InventoryItem from "./components/Pages/InventoryItem/InventoryItem";
import BinLocation from "./components/Pages/BinLocation/BinLocation";
import InboundOrder from "./components/Pages/InboundOrder/InboundOrder";
import OutboundOrder from "./components/Pages/OutboundOrder/OutboundOrder";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/company',
    element: <Company />
  },
  {
    path: '/product',
    element: <Product />
  },
  {
    path: '/inventoryItem',
    element: <InventoryItem />
  },
  {
    path: '/binLocation',
    element: <BinLocation />
  },
  {
    path: '/inboundOrder',
    element: <InboundOrder />
  },
  {
    path: '/outboundOrder',
    element: <OutboundOrder />
  }
];

export default AppRoutes;
