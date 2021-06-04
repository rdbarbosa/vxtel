/* eslint-disable no-console */
/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable @typescript-eslint/no-explicit-any */

import { useEffect, useState } from 'react'
import InputLabel from '@material-ui/core/InputLabel'
import MenuItem from '@material-ui/core/MenuItem'
import FormControl from '@material-ui/core/FormControl'
import Select from '@material-ui/core/Select'
import { Grid, Input } from '@material-ui/core'
import api from '../../services/api'
import { useStyles } from './style'
import Card from '../../components/card'
import { Cidade, Plano, Tarifa } from '../../types'

function Simulador() {
  const classes = useStyles()
  const [cidades, setCidades] = useState<Cidade[]>([])
  const [ooptions, setOoptions] = useState<Cidade[]>([])
  const [doptions, setDoptions] = useState<Cidade[]>([])
  const [tarifas, setTarifas] = useState<Tarifa[]>([])
  const [planos, setPlanos] = useState<Plano[]>([])
  const [error, setError] = useState(false)
  const [values, setValues] = useState<any>({
    origem: '',
    destino: '',
    plano: '',
    tempo: '',
  })
  const [result, setResult] = useState({
    comFalemais: 0,
    semFalemais: 0,
  })

  const handleChange = (prop: any) => (event: any) => {
    setValues({ ...values, [prop]: event.target.value })
  }

  const handleChangeOrigem = (event: any) => {
    setDoptions(
      cidades.filter((c: { codigo: any }) => c.codigo !== event.target.value)
    )
    setValues({ ...values, origem: event.target.value })
  }

  const handleChangeDestino = (event: any) => {
    setOoptions(
      cidades.filter((c: { codigo: any }) => c.codigo !== event.target.value)
    )
    setValues({ ...values, destino: event.target.value })
  }

  useEffect(() => {
    api
      .get('cidades')
      .then((response: any) => {
        setCidades(response.data)
        setOoptions(response.data)
        setDoptions(response.data)
      })
      .catch((err: any) => {
        console.error(`ops! ocorreu um erro${err}`)
      })

    api
      .get('planos')
      .then((response: any) => {
        setPlanos(response.data)
      })
      .catch((err: any) => {
        console.error(`ops! ocorreu um erro${err}`)
      })

    api
      .get('tarifas')
      .then((response: any) => setTarifas(response.data))
      .catch((err: any) => {
        console.error(`ops! ocorreu um erro${err}`)
      })
  }, [])

  useEffect(() => {
    setError(false)
    const tarifa: any = tarifas.find(
      (t: any) => t.origem === values.origem && t.destino === values.destino
    )
    if (!tarifa && values.origem !== '' && values.desino !== '') {
      setResult({
        comFalemais: 0,
        semFalemais: 0,
      })
      setError(true)
      return
    }

    const plano: any = planos.find(
      (p: { minutos: any }) => p.minutos === values.plano
    )
    const tempo = values.tempo - plano?.minutos
    if (values.origem && values.destino) {
      setResult({
        ...result,
        comFalemais: tarifa?.valor * 1.1 * (tempo > 0 ? tempo : 0),
        semFalemais: tarifa?.valor * values.tempo,
      })
    }
  }, [values])

  return (
    <div>
      <Grid container direction='row' justify='center' alignItems='center'>
        <Grid item sm={2} className={classes.grid}>
          <FormControl fullWidth className={classes.formControl}>
            <InputLabel id='origem'>Origem</InputLabel>
            <Select
              labelId='origem'
              id='select_origem'
              value={values.origem}
              onChange={handleChangeOrigem}
            >
              {ooptions.map((item: any) => (
                <MenuItem key={item.codigo} value={item.codigo}>
                  {item.nome}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
        <Grid item sm={2} className={classes.grid}>
          <FormControl fullWidth className={classes.formControl}>
            <InputLabel id='destino'>Destino</InputLabel>
            <Select
              labelId='destino'
              id='select_destino'
              value={values.destino}
              onChange={handleChangeDestino}
            >
              {doptions.map((item: any) => (
                <MenuItem key={item.codigo} value={item.codigo}>
                  {item.nome}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
      </Grid>
      <Grid container direction='row' justify='center' alignItems='center'>
        <Grid item sm={2} className={classes.grid}>
          <FormControl fullWidth className={classes.formControl}>
            <InputLabel id='plano'>Plano</InputLabel>
            <Select
              labelId='plano'
              id='select_plano'
              value={values.plano}
              onChange={handleChange('plano')}
            >
              {planos.map((item: any) => (
                <MenuItem key={item.minutos} value={item.minutos}>
                  {item.nome}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
        <Grid item sm={2} className={classes.grid}>
          <FormControl fullWidth className={classes.formControl}>
            <InputLabel htmlFor='tempo'>Tempo</InputLabel>
            <Input
              id='tempo'
              type='number'
              value={values.tempo}
              onChange={handleChange('tempo')}
            />
          </FormControl>
        </Grid>
      </Grid>
      {error && (
        <Grid container direction='row' justify='center' alignItems='center'>
          Não existe tarifa cadastrada para a origem e destino selecionado
        </Grid>
      )}
      <Grid container direction='row' justify='center' alignItems='center'>
        <Card titulo='Com FaleMais' valor={result.comFalemais.toFixed(2)} />
        <Card titulo='Sem FaleMais' valor={result.semFalemais.toFixed(2)} />
      </Grid>
    </div>
  )
}

export default Simulador
