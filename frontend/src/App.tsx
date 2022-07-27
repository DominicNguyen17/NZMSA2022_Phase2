import axios from "axios";
import { useState } from "react";
import SearchIcon from "@mui/icons-material/Search";
import TextField from "@mui/material/TextField";
import "./App.css";
import { Box, Button, Grid, Paper} from "@mui/material";

function App() {
  const [city, setCity] = useState("");
  const [temperature, setTemperature] = useState("");
  const [cityInfo, setCityInfo] = useState<null | undefined | any>(undefined);
  const [errorMessage, setErrorMessage] = useState('');

  return (
    <div>
      <div className="search-field">
        <h1 style={{ 
          display: "flex", 
          justifyContent: "center",
          alignItems: "center"
          }}>
          ⛅️ Weather App
        </h1>
        
        <div style={{ marginLeft: "24%"}}>
          <TextField style={{ width: "800px"}}
            className="text" 
            value={city}
            onChange={(e) => {
              setCity(e.target.value);
            }}
            label="Enter a City..."
            variant="outlined"
            placeholder="Search..."
            size="small"
          />
            <Button
              onClick={() => {
                search();
              }}
            ><SearchIcon style={{ fill: "blue" }} />
              Search
            </Button>
        </div>
      </div>
      
      {cityInfo === undefined ? (
        <div></div>
      ) : (
        <div
          className="temperature-result"
          style={{ width: "800px", margin: "50px 0px 0px 370px"}}
        >
          <Paper style={{ backgroundColor: "#0E3469"}}>
            <Grid
              container
              direction="row"
              spacing={5}
              style={{
                justifyContent: "center",
              }}
            >
              <Grid item>
                <Box>
                  {cityInfo === undefined || cityInfo === null? (
                    <div style={{color: "#E6EBF2",
                                fontSize: "40px",
                                margin: "0 auto",
                                padding: "0px 10px 10px 30px"}}> 
                      {errorMessage} 
                    </div>
                  ) : (
                    <div style={{color: "#E6EBF2"}}>
                      <h1>
                        {cityInfo}
                      </h1>
                      <div>
                        <p style={{fontSize: "20px",
                                  margin: "0 auto",
                                  padding: "0px 10px 10px 30px",}} >
                          Temperature
                        </p>
                        <p style={{fontSize: "50px",
                                    margin: "0 auto",
                                    padding: "0px 10px 10px 30px",
                                  }}>
                          {Math.round((+temperature))} ℃
                        </p>
                      </div>
                      
                    </div>
                  )}
                </Box>
              </Grid>
            </Grid>
          </Paper>
        </div>
      )}
    </div>
  );
  
  function search() {
    if (city === "" || city === undefined) {
      setErrorMessage("City not found")
      return;
    };
    axios({
      method: "GET",
      url: `https://api.openweathermap.org/data/2.5/weather?q=${city} &appid=32fb8bd4ece0ca0fcc848d9358383450`,
    })
    .then((res) => {
      console.log(res.data);
      setCityInfo(res.data.name + " (" + res.data.sys.country + ")");
      setTemperature(String((res.data.main.temp) - 273.15 * 100 / 100));
    })
    .catch(() => {
      setCityInfo(null);
    })
  };
}

export default App;