import Enzyme, { mount, shallow } from 'enzyme'
import Adapter from '@wojtekmaj/enzyme-adapter-react-17'
import { Input, Select } from '@material-ui/core'
import { act } from 'react-dom/test-utils'
import axios from 'axios'
import api from '../services/api'
import Simulador from '../pages/simulador'

Enzyme.configure({ adapter: new Adapter() })

jest.mock('../services/api')
const mockedAxios = api as jest.Mocked<typeof axios>

it('Simulador loads', () => {
  const wrapper = shallow(<Simulador />)
  const input = wrapper.find(Select).exists()
  expect(input).toEqual(true)
})

describe('Simulador test', () => {
  let wrapper: any

  afterEach(() => {
    jest.clearAllMocks()
  })

  it('Simulador Call API', async () => {
    // mock axios promise

    const cidades = [
      {
        codigo: '011',
        id: 1,
        nome: 'São Paulo',
      },
      {
        codigo: '016',
        id: 2,
        nome: 'Ribeirão Preto',
      },
      {
        codigo: '017',
        id: 3,
        nome: 'São José do Rio Preto',
      },
      {
        codigo: '018',
        id: 4,
        nome: 'Presidente Prudente',
      },
    ]

    const planos = [
      {
        minutos: 30,
        id: 1,
        nome: 'FaleMais 30',
      },
      {
        minutos: 60,
        id: 2,
        nome: 'FaleMais 60',
      },
      {
        minutos: 120,
        id: 3,
        nome: 'FaleMais 120',
      },
    ]

    const tarifas = [
      {
        id: 1,
        origem: '011',
        destino: '016',
        valor: 1.9,
      },
      {
        id: 2,
        origem: '016',
        destino: '011',
        valor: 2.9,
      },
      {
        id: 3,
        origem: '011',
        destino: '017',
        valor: 1.7,
      },
      {
        id: 4,
        origem: '017',
        destino: '011',
        valor: 2.7,
      },
      {
        id: 5,
        origem: '011',
        destino: '018',
        valor: 0.9,
      },
      {
        id: 6,
        origem: '018',
        destino: '011',
        valor: 1.9,
      },
    ]

    await act(async () => {
      mockedAxios.get.mockImplementationOnce(() => Promise.resolve(cidades))
      mockedAxios.get.mockImplementationOnce(() => Promise.resolve(planos))
      mockedAxios.get.mockImplementationOnce(() => Promise.resolve(tarifas))
      wrapper = mount(<Simulador />)
    })

    wrapper
      .find(Select)
      .at(0)
      .props()
      .onChange({ target: { value: '011' } })

    console.log(wrapper)

    wrapper
      .find(Select)
      .at(1)
      .props()
      .onChange({ target: { value: '018' } })

    wrapper
      .find(Select)
      .at(2)
      .props()
      .onChange({ target: { value: 60 } })

    wrapper
      .find(Input)
      .at(3)
      .props()
      .onChange({ target: { value: 60 } })

    // check the render output
    wrapper.update()

    expect(mockedAxios.get).toHaveBeenCalledWith('cidades')

    expect(mockedAxios.get).toHaveBeenCalledWith('planos')

    expect(mockedAxios.get).toHaveBeenCalledWith('tarifas')

    expect(mockedAxios.get).toHaveBeenCalledTimes(3)

    // wrapper.render().find(Select)
    // .at(0)
    // .props()
    // .onChange({ target: { value: 20 } })

    // await expect(wrapper.find('img').props().src).toEqual('image-url')
  })

  it('Simulador Call API Error', async () => {
    // mock axios promise

    await act(async () => {
      mockedAxios.get.mockRejectedValueOnce(() => Promise.resolve([]))
      mockedAxios.get.mockRejectedValueOnce(() => Promise.resolve([]))
      mockedAxios.get.mockRejectedValueOnce(() => Promise.resolve([]))
      wrapper = mount(<Simulador />)
    })

    // check the render output
    wrapper.update()

    expect(mockedAxios.get).toHaveBeenCalledWith('cidades')

    expect(mockedAxios.get).toHaveBeenCalledWith('planos')

    expect(mockedAxios.get).toHaveBeenCalledWith('tarifas')

    wrapper.update()

    expect(mockedAxios.get).toHaveBeenCalledTimes(3)
  })
})
