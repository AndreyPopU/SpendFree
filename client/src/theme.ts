import { createTheme } from "@mui/material/styles";

const theme = createTheme({
  palette: {
    primary: {
      main: "#183B56",
    },
    secondary: {
      main: "#087F8C",
    },
    background: {
      default: "#F5F7FA",
      paper: "#FFFFFF",
    },
    text: {
      primary: "#2A3441",
      secondary: "#64748B",
    },
    success: {
      main: "#218739",
    },
    warning: {
      main: "#B7791F",
    },
    error: {
      main: "#C0392B",
    },
    divider: "#DCE3EA",
  },
});

export default theme;