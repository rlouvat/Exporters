using Autodesk.Maya.OpenMaya;
using GLTFExport.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maya2Babylon.Importer
{
    public class BabylonImporter
    {
        private string fileFullPathName;
        private string fileName;
        private string fileExtension;
        private string directoryName;

        public bool ImportGLTF(string inputFileName)
        {
            fileFullPathName = inputFileName;
            fileName = Path.GetFileName(fileFullPathName);
            fileExtension = Path.GetExtension(fileFullPathName);
            directoryName = Path.GetDirectoryName(fileFullPathName);



            MGlobal.displayInfo("Importing " + inputFileName);
            MGlobal.displayInfo($"fileFullPathName: {fileFullPathName}");
            MGlobal.displayInfo($"fileName: {fileName}");
            MGlobal.displayInfo($"fileExtension: {fileExtension}");
            MGlobal.displayInfo($"directoryName: {directoryName}");
            GLTF gltf = loadData(fileFullPathName);

            if(gltf != null)
            {
                MGlobal.displayInfo($"gltf.asset.version: {gltf.asset.version}");

                createTransform(gltf);
            }

            return true;
        }

        private void createTransform(GLTF gltf)
        {
            //for(int index = 0; index < gltf.nodes.Length; index++)
            //{
            //    GLTFNode node = gltf.nodes[index];
            //    string name = node.name;
            //    if(name == null || name == "")
            //    {
            //        name = $"node{index}";
            //    }

            //    MGlobal.executeCommand($"createNode transform -n \"{name}\";");
            //}

            MFnTransform transform = new MFnTransform();
            MObject mObject = transform.create();
        }

        private GLTF loadData(string file)
        {
            // .gltf
            // read JSON .gltf
            // read buffer .bin
            // get the texture
            GLTF gltf = null;

            switch (fileExtension)
            {
                case ".gltf":
                    // read JSON . gltf
                    gltf = JsonConvert.DeserializeObject<GLTF>(File.ReadAllText(file));

                    // read buffer .bin

                    break;
                case ".glb":
                    using (BinaryReader b = new BinaryReader(File.Open(file, FileMode.Open)))
                    {
                        int lengthStream = (int)b.BaseStream.Length;

                        // TODO check those parameters
                        var magic = b.ReadUInt32();
                        var version = b.ReadUInt32();
                        var length = b.ReadUInt32();
                        var chunkLengthJson = b.ReadUInt32();
                        var chunkTypeJson = b.ReadUInt32();

                        byte[] chunkDataJson = b.ReadBytes((int)chunkLengthJson);
                        string json = Encoding.ASCII.GetString(chunkDataJson);
                        gltf = JsonConvert.DeserializeObject<GLTF>(json);

                        // read buffer
                        // uint32 chunkLength
                        // uint32 chunkType
                        // ubyte[] chunkData

                    }
                    break;
                default:
                    return null;
            }



            return gltf;
        }


        public IList<object> ReadAccessor(GLTFAccessor accessor, GLTFBufferView bufferView, byte[] chunkData)
        {
            IList<object> result = null;

            int offset = bufferView.byteOffset + accessor.byteOffset;
            int count = accessor.count;

            switch (accessor.componentType)
            {
                case GLTFAccessor.ComponentType.BYTE:
                    result = new List<byte>();
                    for (int i = offset; i < count; i++)
                    {
                        result.Add(chunkData[i]);
                    }
                    break;
                case GLTFAccessor.ComponentType.UNSIGNED_SHORT:
                    IList<ushort> us = new List<ushort>();
                    for (int i = offset; i < count; i++)
                    {
                        us.Add(BitConverter.ToUInt16(chunkData, i * 2));
                    }
                    break;
                default:
                    throw new Exception();
            }
            
            return result;
        }

    }
}
