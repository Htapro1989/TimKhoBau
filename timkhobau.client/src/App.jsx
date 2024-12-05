import React, { useState } from "react";
import { Container, TextField, Button, Typography, Grid, Table, TableBody, TableCell, TableRow } from "@mui/material";
import { ValidatorForm, TextValidator } from "react-material-ui-form-validator";
import FormControl from '@mui/material/FormControl';
import FormHelperText from '@mui/material/FormHelperText';
import Input from '@mui/material/Input';
import InputLabel from '@mui/material/InputLabel';

import axios from "axios";

function App() {
  const [n, setN] = useState(3);
  const [m, setM] = useState(3);
  const [p, setP] = useState();
  const [matrix, setMatrix] = useState(Array.from({ length: 3 }, () => Array(3).fill(1)));
  const [result, setResult] = useState(null);
  const [history, setHistory] = useState([]);

  const handleMatrixChange = (i, j, value) => {
    const newMatrix = [...matrix];
    newMatrix[i][j] = value;
    setMatrix(newMatrix);
  };

  const handleSubmit = async () => {
    try {
      const response = await axios.post("https://localhost:7069/api/treasure/solve", {
        n, m, p, matrix,
      });
      setResult(response.data.minFuel);
    } catch (error) {
      console.error(error);
    }
  };
  

  const fetchHistory = async () => {
    try {
      const response = await axios.get("https://localhost:7069/api/treasure/history");
      setHistory(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    
    <Container>
       <ValidatorForm
                onSubmit={handleSubmit}
            >
      <Typography variant="h4" gutterBottom>
        Tìm Kho Báu
      </Typography>
      <Grid container spacing={2}>
        <Grid item xs={4}>
          <TextValidator label="N" type="number"
                    validators={['required']}
                    errorMessages={['this field is required']}
                    value={n} 
                    onChange={(e) => setN(Number(e.target.value))} fullWidth />
        </Grid>
        <Grid item xs={4}>
          <TextValidator label="M" type="number" 
                    validators={['required']}
                    errorMessages={['this field is required']}
                    value={m} 
                    onChange={(e) => setM(Number(e.target.value))} fullWidth />
        </Grid>
        <Grid item xs={4}>
        <TextField label="P (Number of Keys)" 
                    type="number" 
                    value={p}
                    validators={['required']}
                    errorMessages={['this field is required']}
                    onChange={(e) => setP(Number(e.target.value))} 
                    fullWidth />
        </Grid>
      </Grid>

      <Grid container spacing={2} style={{ marginTop: 16 }}>
        {[...Array(n)].map((_, i) => (
          <Grid key={i} container spacing={1}>
            {[...Array(m)].map((_, j) => (
              <Grid item xs={1} key={j}>
                <TextField
                  type="number"
                  onChange={(e) => handleMatrixChange(i, j, Number(e.target.value))}
                />
              </Grid>
            ))}
          </Grid>
        ))}
      </Grid>

      <Button variant="contained" color="primary" type="submit" onClick={handleSubmit} style={{ marginTop: 16 }}>
        Tính Nhiên Liệu
      </Button>
      </ValidatorForm>
      {result && (
        <Typography variant="h6" style={{ marginTop: 16 }}>
          Lượng nhiên liệu nhỏ nhất: {result}
        </Typography>
      )}

      <Button variant="outlined" onClick={fetchHistory} style={{ marginTop: 16 }}>
        Lịch Sử
      </Button>

      {history.length > 0 && (
        <Table>
          <TableBody>
            {history.map((item) => (
              <TableRow key={item.id}>
                <TableCell>N: {item.n}, M: {item.m}, P: {item.p}</TableCell>
                <TableCell>{item.matrix}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      )}
    </Container>
  );
}

export default App;