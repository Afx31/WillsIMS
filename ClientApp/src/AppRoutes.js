import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { FetchDataCustomer } from "./components/FetchDataCustomer";
import { FetchDataOrders } from "./components/FetchDataOrders";

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
    path: '/fetch-data-customer',
    element: <FetchDataCustomer />
  },
  {
    path: '/fetch-data-orders',
    element: <FetchDataOrders />
  }
];

export default AppRoutes;
