import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { FetchDataCompany } from "./components/FetchDataCompany";
import { FetchDataOutboundOrders } from "./components/FetchDataOutboundOrders";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/fetch-data-company',
    element: <FetchDataCompany />
  },
  {
    path: '/fetch-data-outboundOrders',
    element: <FetchDataOutboundOrders />
  }
];

export default AppRoutes;
