import Home from "./components/Pages/Home";
import Company from "./components/Pages/Company";
import Product from "./components/Pages/Product";
import InventoryItems from "./components/Pages/InventoryItems";
import BinLocations from "./components/Pages/BinLocations";
import InboundOrder from "./components/Pages/InboundOrder";
import OutboundOrder from "./components/Pages/OutboundOrder";

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
    path: '/inventoryItems',
    element: <InventoryItems />
  },
  {
    path: '/binLocations',
    element: <BinLocations />
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
