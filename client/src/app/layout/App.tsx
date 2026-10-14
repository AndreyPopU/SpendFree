import { Box, CssBaseline } from "@mui/material";

import NavBar from "./NavBar";
import { Outlet } from "react-router";

function App() {

  return (
    <>
      <CssBaseline />
        <NavBar />
        <Box sx={{ p: 3 }}> <Outlet /> </Box>
    </>
  )
}

export default App