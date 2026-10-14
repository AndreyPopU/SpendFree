import ExpenseWindow from "../../Components/ExpenseWindow";
import ExpenseWidget from "../../Components/ExpenseWidget";
import { Box, Paper, Typography } from '@mui/material';

export default function Dashboard() {
  return (
    <Paper sx={{p:3, width:'60%'}}>
      <Box sx={{ borderRadius: 5, backgroundColor: "background.paper",
                p: 3, border: 2, borderColor: "divider", mb: 3, px: 5,
                justifyContent:'center', alignContent:'center' }} >
        <Typography variant='h3' color="text.primary">SpendFree</Typography>
        <Typography variant='h6' color="text.secondary">Welcome back. Here's your spending summary.</Typography>
      </Box>
    

        <ExpenseWidget />
        <br/>
        <ExpenseWindow />
    </Paper>
    
  )
}
