import Home from "./components/Pages/Home";
import Company from "./components/Pages/Company";
import Products from "./components/Pages/Products";
import InventoryItems from "./components/Pages/InventoryItems";
import BinLocations from "./components/Pages/BinLocations";
import InboundOrders from "./components/Pages/InboundOrders";
import OutboundOrders from "./components/Pages/OutboundOrders";

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
    path: '/products',
    element: <Products />
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
    path: '/inboundOrders',
    element: <InboundOrders />
  },
  {
    path: '/outboundOrders',
    element: <OutboundOrders />
  }
];

export default AppRoutes;
