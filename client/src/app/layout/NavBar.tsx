import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { Button, Container } from '@mui/material';
import { NavLink } from 'react-router';

export default function NavBar() {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static" sx={{ backgroundImage: 'linear-gradient(135deg, #182a73, #218aae 69%, #20a7ac 89%' }}>
                <Container maxWidth='xl'>
                    <Toolbar sx={{ display: 'flex' }}>
                        <IconButton edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
                            <MenuIcon />
                        </IconButton>
                        <Button component={NavLink} to={"/"}
                            variant="text" sx={{ color: 'inherit', mx:2 }} >
                            Dashboard </Button>

                        <Button component={NavLink} to={"/history"}
                            variant="text" sx={{ color: 'inherit', mx:2 }} >
                            History </Button>

                        <Button component={NavLink} to={"/newexpense"}
                            variant="text" sx={{ color: 'inherit', mx:2 }} >
                            New Expense </Button>
                    </Toolbar>
                </Container>

            </AppBar>
        </Box>
    );
}
