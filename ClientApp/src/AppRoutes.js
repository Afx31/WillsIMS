import { Home } from "./components/Home";
import { FetchDataCompany } from "./components/FetchDataCompany";
import { FetchData } from "./components/FetchData";
import { FetchDataBinLocation } from "./components/FetchDataBinLocation";
import { FetchDataInboundOrders } from "./components/FetchDataInboundOrders";
import { FetchDataOutboundOrders } from "./components/FetchDataOutboundOrders";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/fetch-data-company',
    element: <FetchDataCompany />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/fetch-data-binLocation',
    element: <FetchDataBinLocation />
  },
  {
    path: '/fetch-data-inboundOrders',
    element: <FetchDataInboundOrders />
  },
  {
    path: '/fetch-data-outboundOrders',
    element: <FetchDataOutboundOrders />
  }
];

export default AppRoutes;
