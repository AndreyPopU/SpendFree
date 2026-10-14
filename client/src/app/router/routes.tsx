import HistoryPage from "../layout/HistoryPage";
import App from "../layout/App";
import { createBrowserRouter } from "react-router";
import CreateExpense from "../layout/CreateExpense";
import Dashboard from "../layout/Dashboard";

export const router = createBrowserRouter([
    { path: '/', element: <App />, children: [
        {
            index: true,
            element: <Dashboard />,
        },
        {
            path: "history",
            element: <HistoryPage />,
        },
        {
            path: "newexpense",
            element: <CreateExpense />,
        },
    ] },
])